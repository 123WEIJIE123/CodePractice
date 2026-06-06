#pragma once
#include <string>

class GameLogic {
public:
    static std::string getChoiceName(int choice);
    static int judge(int player, int computer);
};

