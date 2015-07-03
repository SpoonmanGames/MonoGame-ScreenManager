---
layout: default
title: Tutoriales
permalink: /tutoriales/
---

{% assign counter = 1 %}
<div class="posts">
  {% for post in site.posts reversed %}
    <article class="post">

      <h1><a href="{{ site.baseurl }}{{ post.url }}">{{ counter }} - {{ post.title }}</a></h1>
      <small>
        {% if site.disqus %}
            <a href="{{ post.url }}#disqus_thread"></a>
        {% endif %}
        {% if post.tags.size > 0 %}
            Tags: 
          {% for tag in post.tags %}
            <a href="/tag/{{ tag }}">{{ tag }} </a>
          {% endfor %}
        {% endif %}
       </small>

      <div class="entry">
        {% if post.summary %}
            {{ post.summary }}
        {% else %}
            {{ post.excerpt}}
        {% endif %}
      </div>
      <br/>
      <a href="{{ site.baseurl }}{{ post.url }}" class="read-more">Leer más ...</a>
    </article>
    {% assign counter=counter | plus:1 %}
  {% endfor %}
</div>