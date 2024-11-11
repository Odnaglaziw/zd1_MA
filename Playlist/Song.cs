namespace Playlist
{
    public struct Song
    {
        public string Author;
        public string Title;
        public string Filename;

        public Song(string author, string title, string filename)
        {
            Author = author;
            Title = title;
            Filename = filename;
        }
    }
}
