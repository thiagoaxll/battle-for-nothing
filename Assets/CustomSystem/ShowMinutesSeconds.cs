using System;
using UnityEngine;

namespace CustomSystem
{
	public static class ShowMinutesSeconds {
		public static string ConvertSecondsToMinutes(float seconds){
			int minutes = (Mathf.FloorToInt(seconds)) / 60;
		
			if(Math.Abs(seconds % 60) > 0){
				seconds = seconds % 60;
			}
			if(seconds >= 59){
				seconds = 59;
			}
		
			if(seconds <= 0){
				return "00:00";
			}
			else if(seconds < 9.5f){
				if(minutes > 9){
					return minutes.ToString() + ":0" + seconds.ToString("F0");
				}else{
					return "0" + minutes.ToString() + ":0" + seconds.ToString("F0");	
				}	
			}
			else{
				if(minutes > 9){
					return minutes.ToString() + ":" + seconds.ToString("F0");
				}else{
					return "0" + minutes.ToString() + ":" + seconds.ToString("F0");
				}
			}

		}	

	}
}
