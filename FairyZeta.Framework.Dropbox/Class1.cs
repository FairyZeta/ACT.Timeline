using System;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;

namespace FairyZeta.Framework.Dropbox
{
    public static class DropTest
    {
        const string tk = "";

        public static void Main()
        {
            var task = Task.Run((Func<Task>)DropTest.Run);
            task.Wait();
        }

        static async Task Run()
        {
            using (var dbx = new DropboxClient(tk))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
                Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);
            }
        }

        public static async Task ListRootFolder()
        {
            using (var dbx = new DropboxClient(tk))
            {
                var list = await dbx.Files.ListFolderAsync(string.Empty);

                // show folders then files
                foreach (var item in list.Entries)
                {
                    if (item.IsFolder)
                    {
                        Console.WriteLine("D  {0}/", item.Name);
                    }
                    else
                    {
                        Console.WriteLine("F{0,8} {1}", item.AsFile.Size, item.Name);
                    }
                }
            }

            //foreach (var item in list.Entries.Where(i => i.IsFile))
            //{
            //    Console.WriteLine("F{0,8} {1}", item.AsFile.Size, item.Name);
            //}
        }

        public static async Task Download()//(string folder, string file)
        {
            using (var dbx = new DropboxClient(tk))
            {
                ListFolderArg arg = new ListFolderArg("/txt");
                var list = await dbx.Files.ListFolderAsync(arg);

                // show folders then files
                foreach (var item in list.Entries)
                {
                    if (item.IsFolder)
                        continue;

                    using (var response = await dbx.Files.DownloadAsync(item.PathLower))
                    {
                        byte[] bs = await response.GetContentAsByteArrayAsync();

                        System.IO.FileStream fs = new System.IO.FileStream(
                            string.Format(@"C:\dropbox\{0}",item.Name),
                            System.IO.FileMode.Create,
                            System.IO.FileAccess.Write);
                        //バイト型配列の内容をすべて書き込む
                        fs.Write(bs, 0, bs.Length);
                        //閉じる
                        fs.Close();

                        //Console.WriteLine(await response.GetContentAsStringAsync());
                    }
                }
            }
        }

        /*
        async Task Upload(DropboxClient dbx, string folder, string file, string content)
        {
            using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                var updated = await dbx.Files.UploadAsync(
                    folder + "/" + file,
                    WriteMode.Overwrite.Instance,
                    body: mem);
                Console.WriteLine("Saved {0}/{1} rev {2}", folder, file, updated.Rev);
            }
        }
        */
    }
}
