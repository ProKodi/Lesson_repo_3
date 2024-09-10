public class TextMethods {
    static int v = 0;
    static void setV(int i)
    {
        v = i;
        System.out.println("Void Method");
    }
    static int getV()
    {
        System.out.println("Returning method");
        return v;
    }
    static int func(int a, int b[])
    {
        a = a+1;
        b[0] = b[0]+1;
        System.out.println("a="+a+"b[0]="+b[0]);
        return a;
    }
    static String compare(int i, int j)
    {
        if(i==j) return -i+ " and " +j+ "are equal";
        else if(i>j) return +i+ "greater than" +j;
        else return +j+ "greater than" +i;
    }
}
