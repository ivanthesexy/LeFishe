using System;
using System.Linq;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace LeFisheGTK
{
    internal class MainWindow : Window
    {
        [UI] private readonly Image imagebox;
        [UI] private readonly Button viewstats;
        [UI] private readonly Button okbutton;

        public MainWindow() : this(new Builder("MainWindow.glade"))
        {
        }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            using (var stream = new System.IO.MemoryStream(ExtractResource("icon.png")))
            {
                Icon = new Gdk.Pixbuf(stream);
            }

            DeleteEvent += Window_DeleteEvent;
            using (var stream = new System.IO.MemoryStream(ExtractResource("fishe.png")))
            {
                imagebox.Pixbuf = new Gdk.Pixbuf(stream);
            }
            okbutton.Clicked += Okbutton_Clicked;
            viewstats.Clicked += Viewstats_Clicked;
        }

        /// <summary>
        /// Code from https://stackoverflow.com/a/23408020/12326569
        /// </summary>
        private static System.Collections.Generic.IEnumerable<string> SplitToLines(string input)
        {
            if (input == null)
            {
                yield break;
            }

            using System.IO.StringReader reader = new System.IO.StringReader(input);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

        private string[]? SyncedItems = null;

        private static string JokesLocation => System.IO.Path.Combine(System.IO.Path.GetTempPath(), "LeFishe-jokes.txt");

        /// <summary>
        /// Copied from https://github.com/Haltroy/HTAlt/blob/master/HTAlt.Standart/Tools.cs#L1486
        /// </summary>
        public static void WriteFile(string fileLocation, string input)
        {
            if (!System.IO.Directory.Exists(new System.IO.FileInfo(fileLocation).DirectoryName)) { System.IO.Directory.CreateDirectory(new System.IO.FileInfo(fileLocation).DirectoryName); }
            if (ReadFile(fileLocation) != input)
            {
                if (System.IO.File.Exists(fileLocation))
                {
                    System.IO.File.Delete(fileLocation);
                }
                System.IO.File.Create(fileLocation).Dispose();
                System.IO.FileStream writer = new System.IO.FileStream(fileLocation, System.IO.FileMode.Open, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite);
                var bytes = System.Text.Encoding.Unicode.GetBytes(input);
                writer.Write(bytes, 0, bytes.Length);
                writer.Close();
            }
        }

        /// <summary>
        /// Copied from https://github.com/Haltroy/HTAlt/blob/master/HTAlt.Standart/Tools.cs#L1417
        /// </summary>
        public static string ReadFile(string fileLocation)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(new System.IO.FileStream(fileLocation, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite), System.Text.Encoding.Unicode);
            string result = sr.ReadToEnd();
            sr.Close();
            return result;
        }

        private void Sync()
        {
            try
            {
                var webC = new System.Net.WebClient();
                var text = webC.DownloadString("https://raw.githubusercontent.com/ivanthesexy/lefishe/main/jokes.txt");
                SyncedItems = SplitToLines(text).ToArray();
                try
                {
                    WriteFile(JokesLocation, text);
                }
                catch (System.Exception sex) { } //ignored.
            }
            catch (System.Exception ex)
            {
                try
                {
                    System.Console.WriteLine("Error on getting jokes, exception caught: {0}", ex.ToString());
                    if (System.IO.File.Exists(JokesLocation) && new System.IO.FileInfo(JokesLocation).Length > 0)
                    {
                        try
                        {
                            var text = ReadFile(JokesLocation);
                            SyncedItems = SplitToLines(text).ToArray();
                        }
                        catch (System.Exception) { } //ignored
                    }
                }
                catch (System.Exception) { } //ignored
            }
        }

        private void Viewstats_Clicked(object sender, EventArgs e)
        {
            try
            {
                Sync();
            }
            catch (System.Exception) { } //ignored
            var funny = new string[] {
                $"genshin impact free waifu hack {System.DateTime.Now.AddYears(2).Year} no virus",
                "agony",
                "how to unshit pants",
                "scientific name of pig",
                "squirrel testicle size",
                "rumpleschnopskins" ,
                "big toilet" ,
                "shrek has swag" ,
                "mlg keanu reeves",
                "polybius rule 34",
                "porn",
                "how to leave Detroit",
                "snowman getting fresh cut",
                "where did my waifu go after taking my meds",
                "how do i write c%23 programs",
                "help my linux distro came without the sex tips",
                $"templeos free crack no virus {System.DateTime.Now.AddYears(2).Year}",
                "is africa made out of chocolate",
                "hi hottie wanna marry",
                "nuclear bomb for arasaka hq best price",
                "half life 3 2001 demo full hd 4k dolby digital",
                $"how to pass exams free download no virus no password no survey {System.DateTime.Now.AddYears(2).Year}",
                "pumped up kicks skrillex remix",
                "shush in turkish",
                "stop killing french people to make french fries",
                "stop killing trans people to make trans fat",
                "the effects of dementia",
                "where is republic of gamers",
                "there's a black man in a suit waiting outside of my house and hes glowing help",
                "mandela catalouge intruder trap rule 34",
                "Best club penguin memes 2015 compilation (legit)",
                "My computer is doing weird things WTF is happenin PLS HALP!!!1%3F",
                "how 2 sex",
                "racoon eating grapes"};
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://google.com/search?q=" + (SyncedItems is null ? funny[new System.Random().Next(0, funny.Length)] : SyncedItems[new System.Random().Next(0, SyncedItems.Length)]).Replace(" ", "+"),
                UseShellExecute = true,
            };
            System.Diagnostics.Process.Start(psi);
            Close();
        }

        private void Okbutton_Clicked(object sender, EventArgs e)
        {
            Close();
        }

        private static byte[] ExtractResource(string filename)
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            using System.IO.Stream resFilestream = a.GetManifestResourceStream(filename);
            if (resFilestream == null) return null;
            byte[] ba = new byte[resFilestream.Length];
            resFilestream.Read(ba, 0, ba.Length);
            return ba;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }
    }
}