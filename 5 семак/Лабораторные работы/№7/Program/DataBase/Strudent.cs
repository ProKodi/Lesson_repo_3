



/// <summary> Студенты со своими специальностями </summary>
record Strudent{
    public readonly string Name;
    public readonly string Parents;
    public readonly string Address;
    public readonly string PhoneNumber; 
    public readonly string passportData;
    public readonly string group;
    public readonly DateTime Birthday;
    public readonly DateTime DateReceipt;
    public readonly bool IsFullTime;
    public readonly int NumberRecordBook;
    public readonly short NuberCourse;
    public readonly long IdSpecialty;

    public Strudent(
        string Name, string Parents, string Address, string PhoneNumber, string passportData,
        string group, DateTime Birthday, DateTime DateReceipt, bool IsFullTime, int NumberRecordBook,
        short NuberCourse, long IdSpecialty
    ){
        this.Name = Name;
        this.Parents = Parents;
        this.Address = Address;
        this.PhoneNumber = PhoneNumber;
        this.passportData = passportData;
        this.group = group;
        this.Birthday = Birthday;
        this.DateReceipt = DateReceipt;
        this.IsFullTime = IsFullTime;
        this.NumberRecordBook = NumberRecordBook;
        this.NuberCourse = NuberCourse;
        this.IdSpecialty = IdSpecialty;
    }
}