#pragma once

#include "stdafx.h"

HHOOK hKeyboardHook = 0;
HHOOK hMouseHook = 0;
HHOOK hShellHook = 0;

LRESULT CALLBACK mouseHookProc(int nCode, WPARAM wParam, LPARAM lParam);

LRESULT CALLBACK keyboardHookProc(int code, WPARAM wParam, LPARAM lParam);

LRESULT CALLBACK shellHookProc(int code, WPARAM wParam, LPARAM lParam);