using System.media;


class Program
{
    static void Main(string[] args)
    {
        List<string> musicFiles = new List<string>();
        string musicDirectory = "CC:\\Users\\azad";

        // Hent alle musikfiler i den angivne mappe
        if (Directory.Exists(musicDirectory))
        {
            string[] files = Directory.GetFiles(musicDirectory, "*.mp3");
            musicFiles.AddRange(files);
        }
        else
        {
            Console.WriteLine("Musikmappen blev ikke fundet.");
            return;
        }

        Console.WriteLine("Velkommen til en simpel musikafspiller!");
        Console.WriteLine("Tilgængelige musiknumre:");

        for (int i = 0; i < musicFiles.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileNameWithoutExtension(musicFiles[i])}");
        }

        while (true)
        {
            Console.Write("Indtast nummeret på den sang, du vil afspille (eller 'q' for at afslutte): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "q")
            {
                break;
            }

            if (int.TryParse(input, out int songNumber) && songNumber >= 1 && songNumber <= musicFiles.Count)
            {
                string selectedSong = musicFiles[songNumber - 1];
                Console.WriteLine($"Afspiller: {Path.GetFileNameWithoutExtension(selectedSong)}");
                PlayMusic(selectedSong);
            }
            else
            {
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
            }
        }
    }

    static void PlayMusic(string filePath)
    {
        using (SoundPlayer player = new SoundPlayer(filePath))
        {
            player.PlaySync(); 
        }
    }
}
