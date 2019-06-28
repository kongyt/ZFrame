using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZFrame {
	public delegate void EventListener<T>(T evt);

	public class EventHandler<T> where T : BaseEvent, new(){
		public EventListener<T> Listener;

		public void AddListener(EventListener<T> listener){
			if(Listener == null){
				Listener = listener;
			}else{
				Listener += listener;
			}
		}

		public void RemoveListener(EventListener<T> listener){
			if(Listener != null){
				Listener -= listener;
			}
		}

		public void SafeHandle(T evt){
			if(Listener != null){
				Listener(evt);
			}
		}
	}

	public class PropertyEventHandler<T> : EventHandler<T> where T : BaseEvent, new(){
		public System.Func<T> getter;

		public PropertyEventHandler(System.Func<T> eventGetter) : base(){
			this.getter = eventGetter;
		}

		public void OnPropertyEvent(){
			this.SafeHandle(getter());		
		}
	}
}

