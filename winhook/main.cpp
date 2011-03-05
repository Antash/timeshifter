#include <windows.h>
#include <tlhelp32.h>

extern "C"
{
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
		LPSTR buff;
		if (wnd)
		{
			int buffLen = GetWindowTextLength(wnd) + 1;
			buff = new char[buffLen];
			GetWindowTextA(wnd, buff, buffLen);
		}
		else
		{
			buff = "no active process";
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
}