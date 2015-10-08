using UnityEngine;
using System.Collections;

//Working Terrain Gen! To "finish" the game and put everything together, I think all that needs to be done is to tie the inventory system to the spawning and to add more blocks. This should be achievable fairly easily by telling the block placement in the Modify script to place different blocks depending on what is selected in the inventory. Same thing with removing blocks, the Modify script removes blocks by replacing them with the air block and this can be set up to only work on certain blocks depending on what tool is selected.

//Interestingly, it loads the same terrain each time. To change this im probably going to have to set something to a random number, but this may not be neccessary for demo purposes. Of course, we do have a week so maybe why not... (or it could be because of those two lines of code that refused to work lol)

//This can be set up for infinate random terrain generation (loading the same terrain each time apparantly unless I do something about it) but I'm not planning on adding that functionality to load and unload terrain unless asked to.

//Chunks are 16 x 16 blocks, and actual world generation is controlled by the world script. Do not make worlds greater than 8x8x3 chunks unless the computer you are working on has a ton of memory. I've tried up to 16X16 and while my comp didn't explode it did take an alarming amount of time to load!

// I could also add caves if you guys really want me to... But Optimization might be more important if this doesnt run well and apparantly caves slows the loading times down significantly...

//If given a choice though I would prefer to figure out how to make different random terrain each time instead of having it load in the exact same one, this isnt covered in the tutorial and I think I know how to do it with random numbers...


public class Notes // : DERP
{
  //Basically a vocab list to help me figure out what all this complex stuff does...

    //Monobehavior is the base class that everything derives from. Helper scripts that are only used through code and don't appear in the scene don't need it.

    // Static: using a "static variable" in a script means (in short) that no matter from what script object, you always acess the same memory. If you have a static variable in a class, it doesnt belong to a single object of that class - it's global for all instances of the class.

    // "A Quaternion represents a rotation. The underlying math is quite complicated but you don't need to understand that to use them with Unity." 
        // A quaternion is not neccesarily an x,y and z rotation. They are similar to vecter threes, but instead of affecting x,y, and z it only effects rotation. It is useful for applying the same rotation to multiple objects, or multiple times to the same object (such as a player).


    //Vertices are vector 3 positions in space that define the points or corners of every triangle in the mesh.

    //Enumerations allow you to create a collection of related constants. The idea is that instead of using an int to represent a set of values, a type with a restricted set of values in used instead

    //The Generic Dictionary provides you with a structure for quickly looking up items from a collection, but you must specify explictly the types for the Keys and Values up-front, when you declare it.

}
