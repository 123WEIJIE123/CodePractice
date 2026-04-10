#include <iostream>
#include <vector>
using namespace std;

int main()
{   
    //C++ auto 相当于 C# var


    cout << "Hello World!\n";
    vector<int> nums = { 1, 2, 3, 4, 5 };
    vector<int> nums1 = { 1, 2, 3, 4, 5 };

    // 打印原始数组
    cout << "原始数组: ";
    for (int i = 0; i < nums.size(); i++) {
        cout << nums[i] << " ";
    }
    cout << endl;

    // 使用 auto& (引用，可以修改原数组)
    for (auto& x : nums) {
        x = x * 2;  // 可以修改原数组
    }
    // nums 变成 {2, 4, 6, 8, 10}

    // 打印第一次修改后的数组
    cout << "第一次修改后 (auto& 乘以2): ";
    for (int i = 0; i < nums.size(); i++) {
        cout << nums[i] << " ";
    }
    cout << endl;

    // 使用 auto (值拷贝，不修改原数组)
    for (auto x : nums1) {
        x = x * 2;  // 只修改拷贝，原数组不变
    }
    // nums 还是 {2, 4, 6, 8, 10}

    // 打印第二次修改后的数组（应该和第一次一样）
    cout << "第二次修改后 (auto 试图再乘以2): ";
    for (int i = 0; i < nums1.size(); i++) {
        cout << nums1[i] << " ";
    }
    cout << endl;

    return 0;
}