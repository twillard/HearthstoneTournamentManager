# HearthstoneTournamentManager

Hearthstone Tournament Manager is a simple application that ties match results from hsreplay.net to a tournament bracket in Challonge.

Example:

https://fat.gfycat.com/EarlyFarawayKagu.webm

## What you will need

* Get an account at challonge.com
* Get your API Key from challonge.com 
...* click username top-right after you're logged in
...* click settings
...* click "Developer API" tab
...* Generate a key
* When you make a tournament at challonge.com
...* Ensure the names of your tournament participants match their hearthstone display names
...* Make sure you 'start' the tournament before using the app

Then just run the app. To update the brackets with the result of a hearthstone match:

* Enter your challonge username/apikey in the appropriate boxes
...* they'll be remembered when you close the app
* enter the tournament you want to modify 
...* If your challonge URL is http://challonge.com/test_tourney then your tournament ID is "test_tourney"
* Click "Fetch Tournament"
...* Once the tournament is successfully loaded, the HSReplay boxes will become available
* Enter a HSReplay match ID into the match box
* Click "Process match"