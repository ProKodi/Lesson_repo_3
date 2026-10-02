



namespace Test;



[Collection("PositiveData")]
public class PositiveTests {
    private readonly PositiveDataFixture _fixture;

    public PositiveTests(PositiveDataFixture fixture) {
        _fixture = fixture;
    }

    [Fact]
    public void Age_ShouldBeValid() {
        foreach (var age in _fixture.Ages) {
            Assert.True(Program.ValidateAge(age));
        }
    }

    [Fact]
    public void Email_ShouldBeValid() {
        foreach (var email in _fixture.Emails) {
            Assert.True(Program.ValidateEmail(email));
        }
    }
}


[Collection("NegativeData")]
public class NegativeTests {
    private readonly NegativeDataFixture _fixture;

    public NegativeTests(NegativeDataFixture fixture) {
        _fixture = fixture;
    }

    [Fact]
    public void Age_ShouldBeInvalid() {
        foreach (var age in _fixture.Ages) {
            Assert.Throws<ArgumentException>(
                () => { Program.ValidateAge(age); }
            );
        }
    }

    [Fact]
    public void Email_ShouldBeInvalid() {
        foreach (var email in _fixture.Emails) {
            Assert.Throws<ArgumentException>(
                () => { Program.ValidateEmail(email); }
            );
        }
    }
}


[Collection("BoundaryData")]
public class BoundaryTests{
    private readonly BoundaryDataFixture _fixture;

    public BoundaryTests(BoundaryDataFixture fixture) {
        _fixture = fixture;
    }

    [Fact]
    public void Age_ShouldBeValid() {
        foreach (var age in _fixture.AgesVal) {
            Assert.True(Program.ValidateAge(age));
        }
    }

    [Fact]
    public void Email_ShouldBeValid() {
        foreach (var email in _fixture.EmailsVal) {
            Assert.True(Program.ValidateEmail(email));
        }
    }

    [Fact]
    public void Age_ShouldBeInValid() {
        foreach (var age in _fixture.AgesInV) {
            Assert.Throws<ArgumentException>(
                () => { Program.ValidateAge(age); }
            );
        }
    }

    [Fact]
    public void Email_ShouldBeInValid() {
        foreach (var email in _fixture.EmailsInV) {
            Assert.Throws<ArgumentException>(
                () => { Program.ValidateEmail(email); }
            );
        }
    }
}