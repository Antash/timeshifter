// wintracer.h

#pragma once

using namespace System;

namespace wintracer {

	public ref class WinTracerMain
	{
	public:
		static int getWindowPID()
		{
			HWND wnd = GetForegroundWindow();
			DWORD processId = -1;
			if (wnd)
			{
				GetWindowThreadProcessId(wnd, &processId);
			}
			return processId;
		}
		
		static TCHAR *getWindowProcName()
		{
			DWORD processId = getWindowPID();

			PROCESSENTRY32 pe;
			HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

			TCHAR *pName;

			if(!hSnapshot || processId == -1)
				pName = (TCHAR *)"no active process";
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
			CloseHandle(hSnapshot); // Done with this snapshot. Free it
			return pName;
		}
	};
}
