namespace apiservicosadm.tests;

[Collection(nameof(DBCollectionFixture))]
public class DBTestBase
{
    protected readonly DbFixture _fixture;

    public DBTestBase(DbFixture fixture)
    {
        _fixture = fixture;
    }
}