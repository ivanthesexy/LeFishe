using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Linq;

namespace LeFishe2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            Sync();
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

            using (System.IO.StringReader reader = new System.IO.StringReader(input))
            {
                string line;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                while ((line = reader.ReadLine()) != null)
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                {
                    yield return line;
                }
            }
        }

        private string[]? SyncedItems = null;

        private string JokesLocation => System.IO.Path.Combine(System.IO.Path.GetTempPath(), "LeFishe-jokes.txt");

        /// <summary>
        /// Copied from https://github.com/Haltroy/HTAlt/blob/master/HTAlt.Standart/Tools.cs#L1486
        /// </summary>
        public static void WriteFile(string fileLocation, string input)
        {
            if (!System.IO.Directory.Exists(new System.IO.FileInfo(fileLocation).DirectoryName)) { System.IO.Directory.CreateDirectory(new System.IO.FileInfo(fileLocation).DirectoryName); }
            if (System.IO.File.Exists(fileLocation))
            {
                System.IO.File.Delete(fileLocation);
            }
            System.IO.File.Create(fileLocation).Dispose();
            if (ReadFile(fileLocation) != input)
            {
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
                System.Console.WriteLine("Error on getting jokes, exception caught: {0}", ex.ToString());
                var fi = new System.IO.FileInfo(JokesLocation);
                if (fi.Exists && fi.Length > 0)
                {
                    var text = ReadFile(JokesLocation);
                    SyncedItems = SplitToLines(text).ToArray();
                }
            }
        }

        private void CrimeClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var funny = new string[] {
                "genshin impact free waifu hack 2022 no virus",
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
                "templeos free crack no virus 2022",
                "is africa made out of chocolate",
                "hi hottie wanna marry",
                "nuclear bomb for arasaka hq best price",
                "half life 3 2001 demo full hd 4k dolby digital",
                "how to pass exams free download no virus no password no survey 2022",
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

        private void OkClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Close();
        }
    }
}