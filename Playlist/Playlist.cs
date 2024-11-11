using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlist
{
    public class Playlist
    {
        private List<Song> list;
        private int currentIndex;

        public Playlist()
        {
            list = new List<Song>();
            currentIndex = 0;
        }
        public Song CurrentSong()
        {
            if (list.Count > 0)
                return list[currentIndex];
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }
        public void AddSong(Song song)
        {
            list.Add(song);
        }
        public void AddSong(Song song, int index)
        {
            if (index < 0 || index > list.Count)
                throw new ArgumentOutOfRangeException("Индекс вне допустимого диапазона.");
            list.Insert(index, song);
        }
        public void Next()
        {
            if (currentIndex < list.Count - 1)
                currentIndex++;
            else
                currentIndex = 0;
        }
        public void Previous()
        {
            if (currentIndex > 0)
                currentIndex--;
            else
                currentIndex = list.Count - 1;
        }
        public void GoTo(int index)
        {
            if (index >= 0 && index < list.Count)
                currentIndex = index;
            else
                throw new ArgumentOutOfRangeException("Индекс вне допустимого диапазона.");
        }
        public void GoToStart()
        {
            currentIndex = 0;
        }
        public void RemoveSong(int index)
        {
            if (index >= 0 && index < list.Count)
            {
                list.RemoveAt(index);
                if (currentIndex >= list.Count)
                    currentIndex = list.Count - 1;
            }
            else
                throw new ArgumentOutOfRangeException("Индекс вне допустимого диапазона.");
        }
        public void RemoveSong(Song song)
        {
            int index = list.FindIndex(s => s.Author == song.Author && s.Title == song.Title && s.Filename == song.Filename);
            if (index >= 0)
                RemoveSong(index);
            else
                throw new ArgumentException("Композиция не найдена.");
        }
        public void Clear()
        {
            list.Clear();
            currentIndex = 0;
        }
        public List<Song> GetAllSongs()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Плейлист пуст.");
                return null;
            }
            return list;
        }
    }
}
