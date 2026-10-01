# LeetCode 1456 — Maximum Number of Vowels in a Substring of Given Length

### 💡 Approach

I solved this problem using the **Sliding Window** technique.

I start by counting the vowels in the first window of size `k`.
Then, I move the window one character at a time.

For each move:

* I check the character entering the window.
* I check the character leaving the window.
* I update the current vowel count.
* I keep track of the maximum count.

This avoids counting the vowels from scratch for every substring.

### ⏱️ Complexity

* **Time:** `O(n)`
* **Space:** `O(1)`

### 📁 Implementation

The solution is implemented in:

`LeetCode/1456_MaxVowelsInSubstring/Solution.cs`

### ✅ Accepted Submission

[View accepted submission on LeetCode](https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/submissions/2157020871/)
