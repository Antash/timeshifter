#include "stdafx.h"

#pragma comment(linker, "/SECTION:.SHARED,RWS")

// instance specific data
HMODULE hInstance = 0;

// DLL load/unload entry point
BOOL APIENTRY DllMain(HANDLE hModule, DWORD  dwReason, LPVOID lpReserved)
{
	switch (dwReason)
	{
	case DLL_PROCESS_ATTACH :
		hInstance = (HINSTANCE) hModule;
		break;
	case DLL_THREAD_ATTACH :
		break;
	case DLL_THREAD_DETACH :
		break;
	case DLL_PROCESS_DETACH :
		break;
	}
	return true;
}