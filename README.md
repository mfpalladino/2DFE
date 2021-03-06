<h1>2DFE</h1>


<p>
2DFE is a flexible level editor for simple 2D games.
</p>


<h2>Idea</h2>

<img src="http://delegadoanonimo.github.io//img/2014-12/2dfe_2.jpg" alt="2DFE" class="img-responsive center-block">

<p>
Suppose your game has one platform, two enemies and an obstacle. During the construction of the level, the editor should allow you to position these "elements" in the places you want them to appear in the game.
</p>

<p>
Using 2DFE you can do the following: 

<ul>
<li>1-In the same directory of editor, create a folder called "Elements".</li>
<li>2-Below the "Elements" folder, create folders for each category of elementsand copy a image that represents that element.</li>
</ul>

<ul>
    <li>
      Elements
      <ul>
        <li>
            Platforms
            <ul>
                <li>Platform1</li>
            </ul>
        </li>
        <li>
            Enemies
            <ul>
                <li>Enemy1</li>
                <li>Enemy2</li>
            </ul>
        </li>
        <li>
            Obstacles
            <ul>
                <li>Obstacle1</li>
            </ul>
        </li>
      </ul>
    </li>
</ul>
</p>

<h2>'F' is flexible</h2>

<img src="http://delegadoanonimo.github.io//img/2014-12/2dfe_1.jpg" alt="Game running" class="img-responsive center-block">

<p>
The result of this arrangement is that you now have a specialized editor for your 2D game. Whatever it is.
</p>

<h2>Reading the elements in your game</h2>

<p>
After that, it will be up to you to read the file generated by the editor in his game. A typical scenario is to build elements factories that are based on the names of pictures: 
</p>

```c#
public static class EnemyFactory 
{
    public static AbstractEnemy Create (string name) 
    {
        if (name == "Enemy1")
            return new Enemy1();
            
        //etc...
    } 
}
```
