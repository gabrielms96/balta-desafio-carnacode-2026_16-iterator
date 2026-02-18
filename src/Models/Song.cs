namespace DesignPatternChallenge.Models;

public class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Genre { get; set; }
    public int DurationSeconds { get; set; }
    public int Year { get; set; }

    public Song(string title, string artist, string genre, int duration, int year)
    {
        Title = title;
        Artist = artist;
        Genre = genre;
        DurationSeconds = duration;
        Year = year;
    }

    public override string ToString() => $"{Title} - {Artist} ({Genre}, {Year})";
}
