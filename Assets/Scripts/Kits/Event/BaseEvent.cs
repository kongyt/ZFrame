namespace ZFrame {

    public abstract class BaseEvent {
        
    }

    public class SimpleEvent<T> : BaseEvent where T : SimpleEvent<T>, new(){
        public static T Create(){
            return new T();
        }
    }

    public class BoolEvent<T> : BaseEvent where T : BoolEvent<T>, new(){
        public bool value;

        public static T Create(bool value){
            var self = new T();
            self.value = value;
            return self;
        }
    }

}
