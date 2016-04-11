using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.CompilerServices;
using FairyZeta.FF14.ACT.Timeline.Core;

namespace FairyZeta.FF14.ACT.Timeline
{
    /// <summary> タイムライン／プラグインインタフェース
    /// </summary>
    public class ACTPlugin : IActPluginV1
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public TimelineCore TimelineCore { get; set; }

        private AssemblyResolverModule asmResolver;
        public string pluginDirectory;

        /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データモニター／プラグインインタフェース／コンストラクタ
        /// </summary>
        public ACTPlugin()
        {
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> [IF] プラグイン停止時の処理を実行します。
        /// </summary>
        public void DeInitPlugin()
        {
            this.TimelineCore.DeInitPlugin();
        }

        /// <summary> [IF] プラグイン開始時の処理を実行します。
        /// </summary>
        /// <param name="pluginScreenSpace"></param>
        /// <param name="pluginStatusText"></param>
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            pluginDirectory = GetPluginDirectory();

            var directories = new List<string>();
            directories.Add(pluginDirectory);
            directories.Add(Path.Combine(pluginDirectory, "dll"));
            asmResolver = new AssemblyResolverModule(directories);

            this.Initialize(pluginScreenSpace, pluginStatusText);
        }

        // AssemblyResolver でカスタムリゾルバを追加する前に PluginMain が解決されることを防ぐために、
        // インライン展開を禁止したメソッドに処理を分離
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Initialize(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            this.TimelineCore = new TimelineCore(pluginScreenSpace, pluginStatusText, pluginDirectory);
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        private string GetPluginDirectory()
        {
            // ACT のプラグインリストからパスを取得する
            // Assembly.CodeBase からはパスを取得できない
            var plugin = ActGlobals.oFormActMain.ActPlugins.Where(x => x.pluginObj == this).FirstOrDefault();
            if (plugin != null)
            {
                return System.IO.Path.GetDirectoryName(plugin.pluginFile.FullName);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
