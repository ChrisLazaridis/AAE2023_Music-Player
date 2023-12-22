namespace AAE2023_Music_Player
{
    public class Track
    {
        private int id;
        private string title { get; set; }
        private string artist { get; set; }
        private string genre { get; set; }
        private int year { get; set; }
        private byte[] MusicFile { get; set; }
        private byte[] image { get; set; }
        private int duration { get; set; }

        public Track(int id, string title, string artist, string genre, int year, int duration, byte[] MusicFile, byte[] image)
        {
            this.id = id;
            this.title = title;
            this.artist = artist;
            this.genre = genre;
            this.year = year;
            this.MusicFile = MusicFile;
            this.image = image;
            this.duration = duration;
        }
    }
}