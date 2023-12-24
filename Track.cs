namespace AAE2023_Music_Player
{
    public class Track
    {
        
        // this class is used to objectify the contents of the database
        
        // variables
        
        private int _id;
        private string _title;
        private string _artist;
        private string _genre;
        private int _year;
        private byte[] _musicFile;
        private byte[] _image;

        // public getters and setters
        
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
            get => _year;
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

        // constructor(ας)
        
        public Track(int id, string title, string artist, string genre, int year, byte[] musicFile,
            byte[] image)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Genre = genre;
            Year = year;
            MusicFile = musicFile;
            Image = image;
        }
    }
}