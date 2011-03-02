// wintracer.h

#pragma once

using namespace System;

namespace wintracer {

	public ref class WinTracerMain
	{
	public:
		static int getWindow()
		{
			HWND wnd;
			wnd = GetForegroundWindow();
			DWORD processId = -1;
			if (wnd)
			{
				GetWindowThreadProcessId(wnd, &processId);
			}
			return processId;
		}
	};
}
