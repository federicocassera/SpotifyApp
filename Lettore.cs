using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyApp
{
    internal class Lettore
    {
        //private List<Content> content;
        // private string songInput;
        private int visualInput;
        private string Choice;
        private string menuChoice;
        private Song inPlaying;
        private List<Song> songs;

        public Lettore(List<Song> s)
        {
            songs = s;
        }

        public void showArtist()
        {
            List<string> artists = (
                from a in songs
                select new { a.artist }).Select(a => a.artist).Distinct().OrderBy(a => a).ToList();
            int i = 0;
            foreach (var item in artists)
            {
                Console.WriteLine($" {i} ; {item}");
                i += 1;
            }
            Menu.ChoseNumber();
            visualInput = int.Parse(Console.ReadLine());
            string selectedArtist = artists[visualInput];
            showAlbums(selectedArtist);
        }

        public void showAlbums(string artist)
        {
            List<string> albums = (
                from a in songs
                where a.artist == artist
                select new { a.album }).Select(a => a.album).Distinct().OrderBy(a => a).ToList();
            int i = 0;
            foreach (var item in albums)
            {
                Console.WriteLine($" {i} ; {item}");
                i += 1;
            }
            Menu.ChoseNumber();
            visualInput = int.Parse(Console.ReadLine());
            string selectedAlbum = albums[visualInput];
            showSongs(selectedAlbum);
        }

        public void showSongs(string album)
        {
            List<string> songList = (
                from a in songs
                where a.album == album
                select new { a.title }).Select(a => a.title).Distinct().OrderBy(a => a).ToList();
            int i = 0;
            foreach (var item in songList)
            {
                Console.WriteLine($" {i} ; {item}");
                i += 1;
            }
            Menu.ChoseNumber();
            visualInput = int.Parse(Console.ReadLine());
            string selectedSong = songList[visualInput];
            InPlaying(selectedSong, album);
        }

        public void InPlaying(string ss, string albu)
        {
            Console.WriteLine("- - - - - - - - - - - - ");
            List<string> Test = (
                from a in songs
                where a.album == albu && a.title == ss
                select new { a.title, a.album }).Select(a => a.title).ToList();
            inPlaying = Test[0];
            Console.WriteLine($"Now is plying {inPlaying}");
            Console.WriteLine("- - - - - - - - - - - - ");
            Menu.ShowMenu();
            menuChoice = Scegli();
        }

        public void NextAction(string choice)
        {
            switch (choice)
            {
                case "f":
                    Next();
                    break;
                case "b":
                    Previous(); 
                    break;
                case "p":
                    Pause(); 
                    break;
                case "e":
                    Exit(); 
                    break;
                default:
                    Console.WriteLine("scelta sbagliata");
                    return;
            }
        }

        public void Next()
        {
            if (numberSongInput < songs.Count - 1)
            {
                numberSongInput += 1;
            }
            else
            {
                numberSongInput = 0;
            }
            CurrentPlay(numberSongInput);
        }

        public void Previous()

        {
            if (numberSongInput > 0)
            {
                numberSongInput -= 1;
            }
            else
            {
                numberSongInput = songs.Count - 1;
            }
            CurrentPlay(numberSongInput);
        }

        public void Pause()
        {
            Console.Write("Now In Pause");
            Menu.ShowMenu();
            menuChoice = Scegli();
            NextAction(menuChoice);
        }

        public void Exit()
        {
            return;
        }

        public string Scegli()
        {
            //Menu.ShowMenu();
            menuChoice = Console.ReadLine();
            return menuChoice;
        }

            /*public void Start()
            {
                Console.WriteLine("- - - - - - - - - - - - - - ");
                ShowList();
                Console.WriteLine("choose number of content");
                numberSongInput = int.Parse(Console.ReadLine());

                CurrentPlay(numberSongInput);
                Console.WriteLine("- - - - - - - - - - - - - - ");



            }

            

            public void ShowList()
            {
                Console.WriteLine("- - - - - - - - - - - - - - ");
                int i = 0;
                foreach (var item in songs)
                {

                    Console.WriteLine($"{i}  {item.title}");
                    i += 1;

                }
                Console.WriteLine("- - - - - - - - - - - - - - ");

            }


            public void CurrentPlay(int numberInput)
            {
                Console.WriteLine("- - - - - - - - - - - - - - ");
                inPlaying = songs[numberInput];
                Console.WriteLine($"Now in Playing: {inPlaying.title}");
                Console.WriteLine("- - - - - - - - - - - - - - ");
                Menu.ShowMenu();
                menuChoice = Scegli();
                NextAction(menuChoice);




            }




            

            */
        }
    }
