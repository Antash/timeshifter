#pragma once

#include "stdafx.h"

HHOOK hKeyboardHook = 0;
HHOOK hMouseHook = 0;
HHOOK hShellHook = 0;
HHOOK hWinMsgHook = 0;

LRESULT CALLBACK mouseHookProc(int nCode, WPARAM wParam, LPARAM lParam);

LRESULT CALLBACK keyboardHookProc(int nCode, WPARAM wParam, LPARAM lParam);

LRESULT CALLBACK shellHookProc(int nCode, WPARAM wParam, LPARAM lParam);

LRESULT CALLBACK winMsgHookProc(int nCode, WPARAM wParam, LPARAM lParam);