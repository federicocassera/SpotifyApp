﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using static System.Net.Mime.MediaTypeNames;

namespace SpotifyApp
{
    internal class FileReader
    {
        //private string selectedArtist;
        //private string selectedAlbum;
        //private string selectedSong;

        public static List<Song> Reader()
        {
            var path = @"C:\Users\federico.cassera\Desktop\Spotify.txt";
            List<Song> songs = new List<Song>();

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(',');

                    Song song = new Song(values[0], values[1], values[2], values[3], values[4]);
                    songs.Add(song);
                }
                return songs;
            }
        }

        
    }
}
