﻿using System;
using System.Collections.Generic;

namespace SpotifyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Song> songs = new List<Song>();
            songs = FileReader.Reader();
            Lettore lettore = new Lettore(songs);
            lettore.showArtist();
        }
    }
}
