using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline
{
    /// <summary> アセンブリリゾルバー
    /// </summary>
    public class AssemblyResolverModule : IDisposable
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public List<string> Directories { get; set; }

        static readonly Regex assemblyNameParser 
            = new Regex(@"(?<name>.+?), Version=(?<version>.+?), Culture=(?<culture>.+?), PublicKeyToken=(?<pubkey>.+)", RegexOptions.Compiled);


      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        public AssemblyResolverModule(IEnumerable<string> directories)
        {
            this.Directories = new List<string>();
            if (directories != null)
            {
                this.Directories.AddRange(directories);
            }
            AppDomain.CurrentDomain.AssemblyResolve += CustomAssemblyResolve1;
        }

        public AssemblyResolverModule()
            : this(null)
        {

        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        public void Dispose()
        {
            AppDomain.CurrentDomain.AssemblyResolve -= CustomAssemblyResolve1;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        public Assembly CustomAssemblyResolve2(Object sender, ResolveEventArgs args)
        {
            System.Reflection.AssemblyName TargetName = new System.Reflection.AssemblyName(args.Name);
            System.Reflection.Assembly ExecutingAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            // 要求のあったアセンブリ名は自分の管轄？
            bool isFind = false;
            System.Reflection.AssemblyName[] ReferencedAssemblies = ExecutingAssembly.GetReferencedAssemblies();
            foreach (System.Reflection.AssemblyName name in ReferencedAssemblies)
            {
                if (System.Reflection.AssemblyName.ReferenceMatchesDefinition(TargetName, name))
                {
                    isFind = true;
                    break;
                }
            }
            if (isFind == false) return null; // 辞退

            // もし読込済みのアセンブリで対応できるならまずそれを使います。
            foreach (System.Reflection.Assembly assm in System.AppDomain.CurrentDomain.GetAssemblies())
            {
                if (System.Reflection.AssemblyName.ReferenceMatchesDefinition(TargetName, assm.GetName())) return assm;
            }

            System.String DllPath = null;
            try
            {
                // DLLを検査するフォルダパスを適当に生成します。DLLのフルパスから、末尾の".dll"を削除して"\lib"を追加するのと同じ処理をします。
                System.String DllLoadDirectory = System.IO.Path.Combine(
                    System.IO.Path.GetDirectoryName(ExecutingAssembly.Location),
                    System.IO.Path.GetFileNameWithoutExtension(ExecutingAssembly.Location) + "\\lib");

                // DLLフォルダパスとAssemblyName.Nameプロパティを使ってそれらしい名前を生成します。
                DllPath = System.IO.Path.Combine(DllLoadDirectory, TargetName.Name + ".dll");
            }
            catch (System.Exception) { return null; } // ウボァー（IO.Pathはぶっちゃけ例外吐きやすい…）。

            // 生成したDllPathをとりあえず読み込んで返します。
            if (System.IO.File.Exists(DllPath))
            {
                try { return System.Reflection.Assembly.LoadFrom(DllPath); }
                catch (System.Exception) { }
            }

            return null;
        }

        private Assembly CustomAssemblyResolve1(object sender, ResolveEventArgs e)
        {
            // Directories プロパティで指定されたディレクトリを基準にアセンブリを検索する
            foreach (var directory in this.Directories)
            {
                var asmPath = "";
                var match = assemblyNameParser.Match(e.Name);
                if (match.Success)
                {
                    var asmFileName = match.Groups["name"].Value + ".dll";
                    if (match.Groups["culture"].Value == "neutral")
                    {
                        asmPath = Path.Combine(directory, asmFileName);
                    }
                    else
                    {
                        asmPath = Path.Combine(directory, match.Groups["culture"].Value, asmFileName);
                    }
                }
                else
                {
                    asmPath = Path.Combine(directory, e.Name + ".dll");
                }

                if (File.Exists(asmPath))
                {   
                    var asm = Assembly.LoadFile(asmPath);
                    
                    OnAssemblyLoaded(asm);
                    return asm;
                }
            }

            return null;
        }

        private Assembly GetAssembly(string path)
        {
            try
            {
                var result = Assembly.LoadFrom(path);
                return result;
            }
            catch (Exception e)
            {
                OnExceptionOccured(e);
            }

            return null;
        }

        protected void OnExceptionOccured(Exception exception)
        {
            if (this.ExceptionOccured != null)
            {
                this.ExceptionOccured(this, new ExceptionOccuredEventArgs(exception));
            }
        }

        protected void OnAssemblyLoaded(Assembly assembly)
        {
            if (this.AssemblyLoaded != null)
            {
                this.AssemblyLoaded(this, new AssemblyLoadEventArgs(assembly));
            }
        }

        public event EventHandler<ExceptionOccuredEventArgs> ExceptionOccured;
        public event EventHandler<AssemblyLoadEventArgs> AssemblyLoaded;

        public class ExceptionOccuredEventArgs : EventArgs
        {
            public Exception Exception {get; set;}
            public ExceptionOccuredEventArgs(Exception exception)
            {
                this.Exception = exception;
            }
        }
    }
}
