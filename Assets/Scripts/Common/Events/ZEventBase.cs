public class ZEventBase<T> where T : new(){

    public static T Create() {
        return new T();
    }

}