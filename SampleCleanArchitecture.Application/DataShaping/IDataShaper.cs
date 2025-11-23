namespace SampleCleanArchitecture.Application.DataShaping
{
    public interface IDataShaper<TEntity>
    {
        IEnumerable<ShapedEntity> ShapeData(IEnumerable<TEntity> entities, string fieldsString);
        ShapedEntity ShapeData(TEntity entity, string fieldsString);
    }
}
