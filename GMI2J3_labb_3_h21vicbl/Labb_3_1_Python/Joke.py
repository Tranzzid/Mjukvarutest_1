import requests

def len_joke():
    joke = get_joke()
    return len(joke)

def get_joke():
    url = "https://api.chucknorris.io/jokes/random"
    
    response = requests.get(url)
    result = response.json()
    
    if response.status_code == 200:
        joke = result["value"]
    else:
        joke = "No jokes are available"
    
    return joke

if __name__ == "__main__":
    print(get_joke())