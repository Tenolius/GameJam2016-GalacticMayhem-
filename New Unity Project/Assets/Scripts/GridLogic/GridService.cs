using UnityEngine;
using System.Collections;

public class GridService : MonoBehaviour, IGridService {

    private static GridService _instance;
    private static object _lock = new object();
    private static bool applicationIsQuitting = false;

    private ISprite[,] grid;

    public int rows, columns;
    public double top, left, width, height;



    public static IGridService Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(GridService) +
                    "' already destroyed on application quit." +
                    " Won't create again - returning null.");
                return null;
            }

            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (GridService)FindObjectOfType(typeof(GridService));

                    if (FindObjectsOfType(typeof(GridService)).Length > 1)
                    {
                        Debug.LogError("[Singleton] Something went really wrong " +
                            " - there should never be more than 1 singleton!" +
                            " Reopening the scene might fix it.");
                        return _instance;
                    }

                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<GridService>();
                        singleton.name = "(singleton) " + typeof(GridService).ToString();

                        DontDestroyOnLoad(singleton);

                        Debug.Log("[Singleton] An instance of " + typeof(GridService) +
                            " is needed in the scene, so '" + singleton +
                            "' was created with DontDestroyOnLoad.");
                    }
                    else
                    {
                        Debug.Log("[Singleton] Using instance already created: " +
                            _instance.gameObject.name);
                    }
                }

                return _instance;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        rows = 0;
        columns = 0;
        top = 0;
        left = 0;
        width = 1;
        height = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /**
     * will return the width of the grid or height of the grid
    */
    public int GetNumberOfRows()
    {
        return rows;
    }
    public int GetNumberOfColumns()
    {
        return columns;
    }
    public double GetTop()
    {
        return top;
    }
    public double GetLeft()
    {
        return left;
    }

    /**
     * BASIC TILE INFORMATION
     * this can be used for calculating size of objects with respect to the grid itself
     */
    public double GetTileWidth()
    {
        return width / columns;
    }
    public double GetTileHeight()
    {
        return height / rows;
    }

    /**
     * This method will get the location of a sprite in the map,
     * NOTE that you may need the id of that element. If the element is not
     * in the grid this method will return null
     * @return the location of that sprite or null if it doesnt exist
     */
    public ILocation GetSpriteLocation(ISprite sprite)
    {
        return null;
    }

    /**
     * If we are doing a defense the tower game, we might need to ask ourselves,
     * what is in our right or what is left of us
     * @return the sprite to the left or right. If there is nothing, then it will retun null
     */
    public object GetSpriteMyLeft(ISprite sprite)
    {
        return null;
    }
    public object GetSpriteMyRight(ISprite sprite)
    {
        return null;
    }

    /**
     * Verify that the location is available, if you are moving to a certain location,
     * you must check if the location is free otheriwse you'll be putting to objects 
     * in the same place which is a no go (generally)
     */
    public bool LocationIsAvailable(ILocation location)
    {
        return false;
    }
    public bool LocationIsAvailable(int x, int y)
    {
        return false;
    }

    /**
     * This will be used normally when you create a new sprite, if you want to move a
     * object from one location to another just use UpdateSpriteLocation
     */
    public void SetSpriteLocation(ISprite sprite, ILocation location)
    {

    }

    /**
     * This is the method that you'll normally call to update the location of the sprite with a location
     */
    public void UpdateSpriteLocation(ISprite sprite, ILocation location)
    {

    }
    /**
     * Same as the last one but we can give it an X and Y location according to Unity position
     * and it will automatically calculate the space on the grid
     * YOU SHOULDN'T BE USING THIS METHOD, IT IS INEFICIENT AND HAS A HUGE OVERHEAD
     * ALWAYS TRY TO USE THE ONE ABOVE
     */
    public void UpdateSpriteLocation(ISprite sprite, double x, double y)
    {

    }

    /**
     * Removes a sprite from the grid, call it when your enemy is defeated or tower. Or when the
     * level ends please remove all sprites from it
     */
    public void RemoveSprite(ISprite sprite)
    {

    }

    /**
     * It will translate the XY location of an object to a ilocation on the grid
     */
    public ILocation TranslateXYLocationToGridLocation(double x, double y)
    {
        return null;
    }

    public void OnDestroy()
    {
        applicationIsQuitting = true;
    }
}
