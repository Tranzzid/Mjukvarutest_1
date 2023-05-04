import  unittest
from unittest.mock import patch, MagicMock
import Joke

class TestJoke(unittest.TestCase):
    
    @patch("Joke.get_joke")
    def test_len_joke(self, mock_get_joke):
        mock_get_joke.return_value = "Jokes on you"
        self.assertEqual(Joke.len_joke(), 12)
        
    @patch("Joke.requests")
    def test_get_joke(self, mock_requests):
        mock_response = MagicMock(status_code = 200)
        mock_response.json.return_value = {"value" : "You are a joke"}
        mock_requests.get.return_value = mock_response
        
        self.assertEqual(Joke.get_joke(), "You are a joke")
        
    
    @patch("Joke.requests")
    def test_get_joke_fail(self, mock_requests):
        mock_response = MagicMock(status_code = 404)
        mock_response.json.return_value = {"value" : "You are a joke"}
        mock_requests.get.return_value = mock_response
        
        self.assertEqual(Joke.get_joke(), "No jokes are available")


if __name__ == "__main__":
    unittest.main()