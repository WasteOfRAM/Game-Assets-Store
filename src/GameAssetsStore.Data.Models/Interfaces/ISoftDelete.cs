namespace GameAssetsStore.Data.Models.Interfaces;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }

    public DateTime? DeletedOn { get; set; }
}
