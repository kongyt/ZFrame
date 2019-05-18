
// 可观察的属性，改变后会通知观察者
public class ZBindableProperty<T> {
    public delegate void PropertyListener(T oldValue, T newValue);

    public PropertyListener propertyListener;

    private T propertyValue;

    public T Value {
        get {
            return propertyValue;
        }
        set {
            if (!object.Equals(propertyValue, value)) {
                T oldValue = propertyValue;
                propertyValue = value;
                NotifyChanged(oldValue, propertyValue);
            }
        }
    }

    private void NotifyChanged(T oldValue, T newValue) {
        if (propertyListener != null) {
            propertyListener(oldValue, newValue);
        }
    }

    private void Observe(PropertyListener listener) {
        if (listener == null) {
            return;
        }
        listener(propertyValue, propertyValue);

        if (propertyListener == null) {
            propertyListener = listener;
        } else {
            propertyListener += listener;
        }
    }

    private void UnObserve(PropertyListener listener) {
        if (listener == null) {
            return;
        }

        if (propertyListener != null) {
            propertyListener -= listener;
        }
    }
	
}
