#include "pch.h"
#include <iostream>

struct list
{
	int field;
	struct list *next;
	struct list *prev;
};

struct list *Create(int a)
{
	struct list *lst;
	lst = (struct list*)malloc(sizeof(struct list));
	lst->field = a;
	lst->next = NULL;
	lst->prev = NULL;
	return(lst);
}

struct list *Add(list *lst, int number)
{
	struct list *temp, *p;
	temp = (struct list*)malloc(sizeof(list));
	p = lst->next;
	lst->next = temp;
	temp->field = number;
	temp->next = p;
	temp->prev = lst;
	if (p != NULL)
		p->prev = temp;
	return(temp);
}

struct list *Remove(list *lst)
{
	struct list *prev, *next;
	prev = lst->prev;
	next = lst->next;
	if (prev != NULL)
		prev->next = lst->next;
	if (next != NULL)
		next->prev = lst->prev;
	free(lst);
	return(prev);
}

void Show(list *lst)
{
	struct list *p;
	p = lst;
	do {
		printf("%d ", p->field);
		p = p->next;
	} while (p != NULL);
}
	

int main()
{
	struct list *L = Create(0) , *t;
	L = Add(L, 2);
	t = Add(L, 6);
	Add(L, 4);
	Remove(t);
	Show(L);
	system("pause");
}