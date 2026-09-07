namespace Test;

public class UnitTest1 {
    /// <summary> Тестирование по длине </summary>
    [Fact]
    public void TestLength(){
        Assert.True( Program.IsValidPassword("12345Gh@nj")); // 10
        Assert.True( Program.IsValidPassword("12345Gh@")); // 8
        Assert.False( Program.IsValidPassword("125Gh@")); // 6
    }

    /// <summary> Тестирование по цыфорке </summary>
    [Fact]
    public void TestDigit(){
        Assert.True( Program.IsValidPassword("iufvgfugvGh123@nj"));
        Assert.False( Program.IsValidPassword("iufvgfugvGh@nj")); 
    }

    /// <summary> Тестирование по большой буковке </summary>
    [Fact]
    public void TestUpChar(){
        Assert.True( Program.IsValidPassword("iufvgfugvGh123@nj"));
        Assert.False( Program.IsValidPassword("iufvgfugv345@nj")); 
    }

    /// <summary> Тестирование по большой буковке </summary>
    [Fact]
    public void TestUSpecChar(){
        Assert.True( Program.IsValidPassword("iufvgfugvGh123@nj"));
        Assert.False( Program.IsValidPassword("iufvgfugv345nj")); 
    }


    /*
    /// <summary> Група поз тестов </summary>
    [Fact]
    public void TrueTest() {
        Assert.True( Program.IsValidPassword("12346789TYpe@gmail.com")); 
        Assert.True( Program.IsValidPassword("vdfiovhdfvoidhoihv2004FFGg@gmail.com"));  
        // гранич
        Assert.True( Program.IsValidPassword("123GH@al")); 
    }

    /// <summary> Група негат тестов </summary>
    [Fact]
    public void FalseTest() {
        Assert.False( Program.IsValidPassword("vdfiovh")); 
        Assert.False( Program.IsValidPassword("12345")); 
        Assert.False( Program.IsValidPassword("12346789tyu@gmail.com")); 
        Assert.False( Program.IsValidPassword("vdfiovhdfvoidhoihv2004@gmail.com")); 

        Assert.False( Program.IsValidPassword("vdkjfbdkjbTYpe@gmail.com")); 
        Assert.False( Program.IsValidPassword("vfhdovidfhvoicxhHJ@gmail.com"));

        Assert.False( Program.IsValidPassword("12346789tyugmailcom")); 
        Assert.False( Program.IsValidPassword("vdfiovhdfvoidhoihv2004gmailcom")); 

        Assert.False( Program.IsValidPassword("")); 

        Assert.False( Program.IsValidPassword(
            new string('@', 1_000)
        ));
    }*/



}
/*
Вопросы:
1) По стилю:
    1) "!@#$%^&*()" - такое пишут в конст классах
    2) Не понятно на чем сломалось

*/
