namespace movieflix_api.Models
{
    public class MovieDetailsModel : MovieModel
    {
        public IList<MovieGenreModel>? Genres { get; set; }
        public int Runtime { get; set; }
        /*
            {
            "adult": false,
            "backdrop_path": "/xFYpUmB01nswPgbzi8EOCT1ZYFu.jpg",
            "belongs_to_collection": null,
            "budget": 60000000,
            "genres": [
                {
                "id": 28,
                "name": "Action"
                },
                {
                "id": 18,
                "name": "Drama"
                },
                {
                "id": 12,
                "name": "Adventure"
                }
            ],
            "homepage": "https://www.granturismo.movie",
            "id": 980489,
            "imdb_id": "tt4495098",
            "original_language": "en",
            "original_title": "Gran Turismo",
            "overview": "The ultimate wish-fulfillment tale of a teenage Gran Turismo player whose gaming skills won him a series of Nissan competitions to become an actual professional racecar driver.",
            "popularity": 3752.83,
            "poster_path": "/51tqzRtKMMZEYUpSYkrUE7v9ehm.jpg",
            "production_companies": [
                {
                "id": 125281,
                "logo_path": "/3hV8pyxzAJgEjiSYVv1WZ0ZYayp.png",
                "name": "PlayStation Productions",
                "origin_country": "US"
                },
                {
                "id": 84792,
                "logo_path": "/7Rfr3Zu6QnHpXW2VdSEzUminAQd.png",
                "name": "2.0 Entertainment",
                "origin_country": "US"
                },
                {
                "id": 5,
                "logo_path": "/wrweLpBqRYcAM7kCSaHDJRxKGOP.png",
                "name": "Columbia Pictures",
                "origin_country": "US"
                }
            ],
            "production_countries": [
                {
                "iso_3166_1": "US",
                "name": "United States of America"
                }
            ],
            "release_date": "2023-08-09",
            "revenue": 114800000,
            "runtime": 135,
            "spoken_languages": [
                {
                "english_name": "English",
                "iso_639_1": "en",
                "name": "English"
                },
                {
                "english_name": "German",
                "iso_639_1": "de",
                "name": "Deutsch"
                },
                {
                "english_name": "Japanese",
                "iso_639_1": "ja",
                "name": "日本語"
                }
            ],
            "status": "Released",
            "tagline": "From gamer to racer.",
            "title": "Gran Turismo",
            "video": false,
            "vote_average": 8.049,
            "vote_count": 738
            }            
        
        */
    }
}