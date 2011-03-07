#include "stdafx.h"
#include "hooks.h"

extern HMODULE hInstance;

int childCount = 0;
char wn[1000][1000];

bool CALLBACK childWindowEnumProc(HWND wnd, LPARAM lParam)
{
	char buff[100];
	if (wnd)
	{
		int buffLen = GetWindowTextLength(wnd) + 1;
		GetWindowTextA(wnd, buff, buffLen);
		strcpy(wn[childCount], buff);
		childCount++;
		return true;
	}
	return false;
}

extern "C"
{
	__declspec(dllexport) void initHooks()
	{
		hShellHook = SetWindowsHookEx(WH_SHELL, shellHookProc, hInstance, 0);
		hMouseHook = SetWindowsHookEx(WH_MOUSE, mouseHookProc, hInstance, 0);
		hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD, keyboardHookProc, hInstance, 0);
	}

	__declspec(dllexport) void rmHooks()
	{
		UnhookWindowsHookEx(hShellHook);
		UnhookWindowsHookEx(hMouseHook);
		UnhookWindowsHookEx(hKeyboardHook);
	}

	__declspec(dllexport) int getActWindowPID()
	{
		HWND wnd = GetForegroundWindow();
		DWORD processId = -1;
		if (wnd)
		{
			GetWindowThreadProcessId(wnd, &processId);
		}
		return processId;
	}

	__declspec(dllexport) void getActWindowCaption(LPSTR windowText)
	{
		HWND wnd = GetForegroundWindow();
		char buff[100] = "no active process";
		if (wnd)
		{
			int buffLen = GetWindowTextLength(wnd) + 1;
			//buff = new char[buffLen];
			GetWindowTextA(wnd, buff, buffLen);
		}
		else
		{
			//buff = "no active process";
		}
		strcpy(windowText, buff);
	}

	__declspec(dllexport) LPWSTR getActWindowProcName()
	{
		DWORD processId = getActWindowPID();

		static PROCESSENTRY32 pe;
		HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

		LPWSTR pName;

		if(!hSnapshot || processId == -1)
		{
			pName = L"no active process";
		}
		else
		{
			// Initialize size in structure
			pe.dwSize = sizeof(PROCESSENTRY32);

			for(int i = Process32First(hSnapshot, &pe); i; i=Process32Next(hSnapshot, &pe))
			{
				if(pe.th32ProcessID == processId)
				{
					pName = pe.szExeFile;
					break;
				}
			}
		}
		CloseHandle(hSnapshot); // free snapshot
		return pName;
	}

	__declspec(dllexport) void getActWindowChildren(LPSTR childWindows)
	{
		//TODO AA : find soluthin!
		//HWND wnd = GetForegroundWindow();
		//char buff[1000];
		//strcpy(buff,"");
		//if (wnd)
		//{
		//	childCount = 0;
		//	bool f = EnumChildWindows(wnd, (WNDENUMPROC)childWindowEnumProc, 1);
		//	for (int i = 0; i < childCount; i++)
		//	{
		//		strcat(buff, wn[i]);
		//		//MessageBoxA(0,buff,wn[i],0);
		//	}
		//	strcpy(childWindows, buff);
		//	//MessageBoxA(0,buff,"2",0);
		//}
	}
}