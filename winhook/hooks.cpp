#include "stdafx.h"

extern HHOOK hKeyboardHook;
extern HHOOK hMouseHook;

LRESULT CALLBACK mouseHookProc(int nCode, WPARAM wParam, LPARAM lParam)
{
	//MessageBoxA(NULL, "mouse", "mouse", NULL);
	return 0;
}

LRESULT CALLBACK keyboardHookProc(int nCode, WPARAM wParam,LPARAM lParam) 
{ 
	int flags;	
	bool handledHere = false;
	int virtualKeycode = 0;
	int scanCode = 0;
	bool isDown = false;
	PKBDLLHOOKSTRUCT hs;
	char buff[10];

	if(nCode >= 0) //No action
	{
		hs = (PKBDLLHOOKSTRUCT)lParam;
		flags = hs->flags;
		scanCode = hs->scanCode; 
		virtualKeycode = hs->vkCode;
		MessageBoxA(NULL, "key", "key", NULL);
	}
	return 0;
}