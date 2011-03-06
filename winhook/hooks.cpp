#include "stdafx.h"

extern HHOOK hKeyboardHook;
extern HHOOK hMouseHook;
extern HHOOK hShellHook;

LRESULT CALLBACK shellHookProc(int nCode, WPARAM wParam, LPARAM lParam)
{
	if(nCode < 0)
	{
		return CallNextHookEx(hShellHook, nCode, wParam, lParam);
	}
	//Active window changed
	if (nCode == HSHELL_WINDOWACTIVATED)
	{
		//MessageBeep(0xffffffff);
	}
	//Active window redrawed (works, but not correct)
	//else if (nCode == HSHELL_REDRAW)
	//{
	//	MessageBeep(0xffffffff);
	//}
	return CallNextHookEx(hShellHook, nCode, wParam, lParam);
}

LRESULT CALLBACK mouseHookProc(int nCode, WPARAM wParam, LPARAM lParam)
{
	if(nCode < 0)
	{
		return CallNextHookEx(hMouseHook, nCode, wParam, lParam);
	}
	if (nCode == HC_ACTION)
	{
		// place handler here
	}
	return CallNextHookEx(hMouseHook, nCode, wParam, lParam);
}

LRESULT CALLBACK keyboardHookProc(int nCode, WPARAM wParam,LPARAM lParam) 
{ 
	if(nCode < 0)
	{
		return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
	}
	if (nCode == HC_ACTION)
	{
		// place handler here
	}
	return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
}