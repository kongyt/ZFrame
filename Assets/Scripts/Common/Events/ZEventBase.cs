public class ZEventBase<T> where T : new(){
    public static T Create(){
        return new T();
    }

}

public class ZBoolEventBase<T> : ZEventBase<T> where T : new(){    
    public bool flag = false;
}