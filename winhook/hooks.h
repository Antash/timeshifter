#pragma once

#include "stdafx.h"

LRESULT CALLBACK mouseHookProc(int nCode, WPARAM wParam, LPARAM lParam);

LRESULT CALLBACK keyboardHookProc(int code,WPARAM wParam,LPARAM lParam);