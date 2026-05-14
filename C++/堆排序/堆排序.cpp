#include <iostream>
#include <vector>       // vector需要添加
#include <algorithm>    // 需要添加（为了 swap）
using namespace std;

void HeapCompare(vector<int>& arr, int nowIndex, int arrLength);
void HeapSort(vector<int>& nums);

int main()
{
    cout << "Hello World!\n";

    // 测试数组
    vector<int> nums = { 3, 2, 1, 5, 6, 4 };
    cout << "原始数组: ";
    for (int num : nums) {
        cout << num << " ";
    }
    cout << endl;

    // 构建大根堆
    HeapSort(nums);
   
    cout << "堆排序后的数组: ";
    for (int num : nums) {
        cout << num << " ";
    }
    cout << endl;

}

// 第一步：实现父节点和左右节点比较
void HeapCompare(vector<int>& arr, int nowIndex, int arrLength) {
    int leftIndex = 2 * nowIndex + 1;
    int rightIndex = 2 * nowIndex + 2;
    int biggerIndex = nowIndex;

    if (leftIndex < arrLength && arr[leftIndex] > arr[biggerIndex]) {
        biggerIndex = leftIndex;
    }
    if (rightIndex < arrLength && arr[rightIndex] > arr[biggerIndex]) {
        biggerIndex = rightIndex;
    }
    if (biggerIndex != nowIndex) {
        swap(arr[biggerIndex], arr[nowIndex]);
        HeapCompare(arr, biggerIndex, arrLength);
    }
}


//构建大根堆
void BuildHeapTop(vector<int>& arr) {
    for (int i = arr.size() / 2 - 1; i >= 0; i--) {
        HeapCompare(arr, i, arr.size());
    }

}

void HeapSort(vector<int>& nums) {
    BuildHeapTop(nums);
    for (int i = nums.size() - 1; i >= 1; i--) {
        swap(nums[0], nums[i]);
        HeapCompare(nums, 0, i);
    }
}

