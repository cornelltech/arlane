# arlane

Arlane is an exploration into how mixed reality can augmate real life shopping. ***This readme is a work in progress***

## Requirements
1. Hololens
2. Unity
3. Windows Machine


## How to setup
1. git clone this project
1a. The Holotoolkit should be included in the ```Assets/``` folder, but if not then import the package from [here](https://github.com/Microsoft/HoloToolkit-Unity)
2. In unity open the main scene ```Assets/_Scenes/Main.unity```
3. You should see a ```Holotoolkit``` menu item in the Unity IDE, click that and then ```Build```
4. Select ```Build SLN``` this will build a Visual Studio Solution Project
5. Open the Visual Studio Solution Project in Visual Studio and then make sure that you are building ```Release``` and for ```x86``` for ```Remote Machine```
6. ```Build without debug``` 
6a. At this point you may be prompted for an ```IP Address```, if so enter the one given by your Hololens.

## Basic app overview
There is an entry point called ```AppManager``` which is attached to the ```Managers``` game object. This is the main singleton which acts as the entry point and keeps track of the state.

The list of prefabs are
1. ```Jumbotron``` - Displays a video file and subscribes to the gaze gesture recognizer
2. ```ShoppingList``` - Displays the list of items selected to buy from the companion app
3. ```ItemComponent``` - Handles the ```Item```, ```Scanner```, and ```Card``` gameobjects

Misc
1. ```StickyManager.cs``` - A script which can be attached to a gameobject to give it anchor support (i.e. persist locations between app sessions)


## Voice Commands
1. ```Show Shopping List``` - Show the shopping list
2. ```Hide Shopping List``` - Hide the shopping list
3. ```Show Items``` (Admin Mode) - Show the collision surfaces for the items
4. ```Hide Items``` (Admin Mode) - Hide the collision surfaces for the items
5. ```Clear``` - Dismiss a card
