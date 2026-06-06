#include "GameLogic.h"

std::string GameLogic::getChoiceName(int choice) {
    switch (choice) {
    case 1: return "棒";
    case 2: return "老虎";
    case 3: return "鸡";
    case 4: return "虫";
    default: return "未知";
    }
}

int GameLogic::judge(int player, int computer) {
    if (player == computer) return 0;

    // 玩家赢的情况
    if ((player == 1 && computer == 2) ||
        (player == 2 && computer == 3) ||
        (player == 3 && computer == 4) ||
        (player == 4 && computer == 1)) {
        return 1;
    }

    // 平局特殊情况
    if ((player == 1 && computer == 3) ||
        (player == 2 && computer == 4)) {
        return 0;
    }

    return -1;
}

int main()
{
    return 0;
}