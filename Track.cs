namespace AAE2023_Music_Player
{
    public class Track
    {
        private int _id;
        private string _title;
        private string _artist;
        private string _genre;
        private int _year;
        private byte[] _musicFile;
        private byte[] _image;
        private int _duration;

        public int Id
        {
            get => _id;
            protected set => _id = value;
        }

        public string Title
        {
            get => _title;
            protected set => _title = value;
        }

        public string Artist
        {
            get => _artist;
            protected set => _artist = value;
        }

        public string Genre
        {
            get => _genre;
            protected set => _genre = value;
        }

        public int Year
        {
            get { return _year; }
            protected set { _year = value; }
        }

        public byte[] MusicFile
        {
            get => _musicFile;
            protected set => _musicFile = value;
        }

        public byte[] Image
        {
            get => _image;
            protected set => _image = value;
        }

        public int Duration
        {
            get => _duration;
            protected set => _duration = value;
        }

        public Track(int id, string title, string artist, string genre, int year, int duration, byte[] musicFile,
            byte[] image)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Genre = genre;
            Year = year;
            MusicFile = musicFile;
            Image = image;
            Duration = duration;
        }
    }
}