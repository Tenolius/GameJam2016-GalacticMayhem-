using UnityEngine;
using System.Collections;


public interface IGridService
{
    // Basic grid information

    /**
     * will return the width of the grid or height of the grid
     */
    int GetNumberOfRows();
    int GetNumberOfColumns();

    /**
     * BASIC TILE INFORMATION
     * this can be used for calculating size of objects with respect to the grid itself
     */
    float GetTileWidth();
    float GetTileHeight();

    /**
     * This method will get the location of a sprite in the map,
     * NOTE that you may need the id of that element. If the element is not
     * in the grid this method will return null
     * @return the location of that sprite or null if it doesnt exist
     */
    ILocation GetSpriteLocation(ISprite sprite);

    /**
     * If we are doing a defense the tower game, we might need to ask ourselves,
     * what is in our right or what is left of us
     * @return the sprite to the left or right. If there is nothing, then it will retun null
     */
    object GetSpriteMyLeft(ISprite sprite);
    object GetSpriteMyRight(ISprite sprite);

    /**
     * Verify that the location is available, if you are moving to a certain location,
     * you must check if the location is free otheriwse you'll be putting to objects 
     * in the same place which is a no go (generally)
     */
    bool LocationIsAvailable(ILocation location);
    bool LocationIsAvailable(int x, int y);

    /**
     * This will be used normally when you create a new sprite, if you want to move a
     * object from one location to another just use UpdateSpriteLocation
     */
    void SetSpriteLocation(ISprite sprite, ILocation location);

    /**
     * This is the method that you'll normally call to update the location of the sprite with a location
     */
    void UpdateSpriteLocation(ISprite sprite, ILocation location);
    /**
     * Same as the last one but we can give it an X and Y location according to Unity position
     * and it will automatically calculate the space on the grid
     * YOU SHOULDN'T BE USING THIS METHOD, IT IS INEFICIENT AND HAS A HUGE OVERHEAD
     * ALWAYS TRY TO USE THE ONE ABOVE
     */
    void UpdateSpriteLocation(ISprite sprite, float x, float y);

    /**
     * It will translate the XY location of an object to a ilocation on the grid
     */
    ILocation TranslateXYLocationToGridLocation(float x, float y);
}

public interface ISprite
{
    int getUID();
}

public interface ILocation
{
    int GetXGrid();
    int GetYGrid();
    object GetSprite();
}
