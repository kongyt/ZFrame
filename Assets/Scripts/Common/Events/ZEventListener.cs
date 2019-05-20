using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public delegate void ZEventListener<T>(T evt);

public class ZEventHandler<T> where T : ZEventBase<T>, new(){
	public ZEventListener<T> Listener;

	public void AddListener(ZEventListener<T> listener){
		if(Listener == null){
			Listener = listener;
		}else{
			Listener += listener;
		}
	}

	public void RemoveListener(ZEventListener<T> listener){
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

public class ZPropertyEventHandler<T> : ZEventHandler<T> where T : ZEventBase<T>, new(){
	public System.Func<T> getter;

	public ZPropertyEventHandler(System.Func<T> eventGetter) : base(){
		this.getter = eventGetter;
	}

	public void OnPropertyEvent(){
		this.SafeHandle(getter());		
	}
}