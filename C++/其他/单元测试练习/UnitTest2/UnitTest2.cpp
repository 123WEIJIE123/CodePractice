#include "pch.h"
#include "CppUnitTest.h"
#include "../GameLogic/GameLogic.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTestGameLogic
{
    TEST_CLASS(UnitTestGameLogic)
    {
    public:
        // 测试 getChoiceName 函数
        TEST_METHOD(TestGetChoiceName_Valid)
        {
            Assert::AreEqual(std::string("棒"), GameLogic::getChoiceName(1));
            Assert::AreEqual(std::string("老虎"), GameLogic::getChoiceName(2));
            Assert::AreEqual(std::string("鸡"), GameLogic::getChoiceName(3));
            Assert::AreEqual(std::string("虫"), GameLogic::getChoiceName(4));
        }

        TEST_METHOD(TestGetChoiceName_Invalid)
        {
            Assert::AreEqual(std::string("未知"), GameLogic::getChoiceName(0));
            Assert::AreEqual(std::string("未知"), GameLogic::getChoiceName(5));
            Assert::AreEqual(std::string("未知"), GameLogic::getChoiceName(100));
        }

        // 测试平局情况（相同选择）
        TEST_METHOD(TestJudge_Tie_SameChoice)
        {
            for (int i = 1; i <= 4; i++) {
                Assert::AreEqual(0, GameLogic::judge(i, i));
            }
        }

        // 测试平局特殊情况（棒打鸡 → 平局）
        TEST_METHOD(TestJudge_Tie_StickVsChicken)
        {
            // 玩家出棒(1)，电脑出鸡(3) → 平局
            Assert::AreEqual(0, GameLogic::judge(1, 3));
            // 玩家出鸡(3)，电脑出棒(1) → 这种情况电脑赢？检查逻辑
            Assert::AreEqual(-1, GameLogic::judge(3, 1));
        }

        // 测试平局特殊情况（老虎不吃虫）
        TEST_METHOD(TestJudge_Tie_TigerVsBug)
        {
            // 玩家出老虎(2)，电脑出虫(4) → 平局
            Assert::AreEqual(0, GameLogic::judge(2, 4));
            // 玩家出虫(4)，电脑出老虎(2) → 电脑赢
            Assert::AreEqual(-1, GameLogic::judge(4, 2));
        }

        // 测试玩家赢：棒(1)打老虎(2)
        TEST_METHOD(TestJudge_PlayerWin_StickVsTiger)
        {
            Assert::AreEqual(1, GameLogic::judge(1, 2));
        }

        // 测试玩家赢：老虎(2)吃鸡(3)
        TEST_METHOD(TestJudge_PlayerWin_TigerVsChicken)
        {
            Assert::AreEqual(1, GameLogic::judge(2, 3));
        }

        // 测试玩家赢：鸡(3)吃虫(4)
        TEST_METHOD(TestJudge_PlayerWin_ChickenVsBug)
        {
            Assert::AreEqual(1, GameLogic::judge(3, 4));
        }

        // 测试玩家赢：虫(4)蛀棒(1)
        TEST_METHOD(TestJudge_PlayerWin_BugVsStick)
        {
            Assert::AreEqual(1, GameLogic::judge(4, 1));
        }

        // 测试电脑赢：电脑出棒(1)打玩家老虎(2)
        TEST_METHOD(TestJudge_ComputerWin_StickVsTiger)
        {
            Assert::AreEqual(-1, GameLogic::judge(2, 1));
        }

        // 测试电脑赢：电脑出老虎(2)吃玩家鸡(3)
        TEST_METHOD(TestJudge_ComputerWin_TigerVsChicken)
        {
            Assert::AreEqual(-1, GameLogic::judge(3, 2));
        }

        // 测试电脑赢：电脑出鸡(3)吃玩家虫(4)
        TEST_METHOD(TestJudge_ComputerWin_ChickenVsBug)
        {
            Assert::AreEqual(-1, GameLogic::judge(4, 3));
        }

        // 测试电脑赢：电脑出虫(4)蛀玩家棒(1)
        TEST_METHOD(TestJudge_ComputerWin_BugVsStick)
        {
            Assert::AreEqual(-1, GameLogic::judge(1, 4));
        }

        // 组合测试：测试所有可能的对战结果
        TEST_METHOD(TestJudge_AllCombinations)
        {
            // 预期结果矩阵 [玩家][电脑] = 结果
            // 1=棒,2=老虎,3=鸡,4=虫
            // 结果: 1=玩家赢, -1=电脑赢, 0=平局
            int expected[5][5] = { {0} };

            // 初始化预期结果
            for (int i = 1; i <= 4; i++) expected[i][i] = 0;      // 相同 = 平局
            expected[1][2] = 1; expected[2][1] = -1;              // 棒 vs 老虎
            expected[2][3] = 1; expected[3][2] = -1;              // 老虎 vs 鸡
            expected[3][4] = 1; expected[4][3] = -1;              // 鸡 vs 虫
            expected[4][1] = 1; expected[1][4] = -1;              // 虫 vs 棒
            expected[1][3] = 0; expected[3][1] = -1;              // 棒 vs 鸡（特殊平局）
            expected[2][4] = 0; expected[4][2] = -1;              // 老虎 vs 虫（特殊平局）

            // 测试所有组合
            for (int player = 1; player <= 4; player++) {
                for (int computer = 1; computer <= 4; computer++) {
                    int result = GameLogic::judge(player, computer);
                    Assert::AreEqual(expected[player][computer], result,
                        (L"玩家=" + std::to_wstring(player) +
                         L",电脑=" + std::to_wstring(computer)).c_str());
                }
            }
        }
    };
}