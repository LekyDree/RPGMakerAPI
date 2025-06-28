namespace RPGMakerAPI.Interfaces
{
    public interface IBelongsToUserChild
    {
        object? GetParent(); // Can return IBelongsToUser or another IBelongsToUserChild
    }

}
