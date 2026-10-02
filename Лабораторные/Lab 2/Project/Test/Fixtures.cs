



public class PositiveDataFixture{
    public List<int> Ages { get; } = [ 25, 40, 50 ];

    public List<string> Emails { get; } = [
        "test@mail.com", "admin@example.ru", "user@test.com"
    ];
}

[CollectionDefinition("PositiveData")]
public class PositiveFixture : ICollectionFixture<PositiveDataFixture>{}


public class NegativeDataFixture {
    public List<int> Ages { get; } = [ 17, 66, -1 ];

    public List<string> Emails { get; } = [
        "testmail.com", "adminexample.ru", "user"
    ];
}

[CollectionDefinition("NegativeData")]
public class NegativeFixture : ICollectionFixture<NegativeDataFixture>{}


public class BoundaryDataFixture{
    public List<int> AgesVal { get; } = [ 18, 19, 64, 65 ];

    public List<string> EmailsVal { get; } = [ "a@b.c", "test@example.com" ];

    public List<int> AgesInV { get; } = [ 17, 66 ];

    public List<string> EmailsInV { get; } = [ 
        "9jjab.c", "9jjabjc", "99kug@bc", "a@.c"
    ];
}

[CollectionDefinition("BoundaryData")]
public class BoundaryFixture : ICollectionFixture<BoundaryDataFixture>{}